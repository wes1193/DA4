using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.DTOs;
using API.Extensions;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        // private readonly DataContext _context;
        private readonly IMapper _mapper;

        private readonly IPhotoService _photoService;

        private API.Extensions.LoggingExtensions _Logger = null;

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        public UsersController( IUserRepository userRepository
                                , IMapper mapper
                                , IPhotoService photoService   )
        {
            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] >>>>>>>> API UsersControler - Constructor");
            
            _photoService = photoService;
            _mapper = mapper;
            _userRepository = userRepository;

            _Logger = new API.Extensions.LoggingExtensions();
            
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        [HttpGet] 
        /*[AllowAnonymous]*/
       //public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
       public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            //var users = _context.Users.ToList();
            //return users;
            //return await  _context.Users.ToListAsync();
            
            //var users = await _userRepository.GetUsersAsync(); 
            // return Ok(users);
            //return Ok(await _userRepository.GetUsersAsync()); 

            // var users = await _userRepository.GetUsersAsync();
            // var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            // return Ok(usersToReturn); 

            _Logger.LogMsg2Console(">>>>>>>> API UsersControler GetUsers [HttpGet]");
            var users = await _userRepository.GetMembersAsync();
            return Ok(users); 
        }




        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        [HttpGet("{username}", Name ="GetUser")]
        //public async Task<ActionResult<AppUser>> GetUser(string username)
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            // var user = _context.Users.Find(id);
            // return user;
            
            // return await  _context.Users.FindAsync(id);
            // return await _userRepository.GetUserByUsernameAsync(username);

            _Logger.LogMsg2Console(">>>>> API UsersControler - GetUser [HttpGet] - username: " + username.ToString() + "\n");    
            //var user  = await _userRepository.GetUserByUsernameAsync(username);
            //return  _mapper.Map<MemberDto>(user);

            return  await _userRepository.GetMemberAsync(username);                        
        }



        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto )
        {  
            _Logger.LogMsg2Console(">>>>>>> API UsersControler UpdateUser [HttpPut] \n");
             
             /* get the username from the TOkEN that the APi is using to pass back and forth from the client */
             
             // var username  = User.GetUsername();  not needed anymore
            _Logger.LogMsg2Console(">>>>>>>> API UsersControler UpdateUser - " + User.GetUsername());

             // get the user from the db
             var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
            _Logger.LogMsg2Console("  >>>>>>>> API UsersControler UpdateUser - id = " + user.Id);

             _mapper.Map(memberUpdateDto, user);  // maps from one obj to ob using Helpers\automapper
            _Logger.LogMsg2Console(">>>>>>>> API UsersControler UpdateUser - memberUpdateDto = " + memberUpdateDto);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync())       
                {
                    _Logger.LogMsg2Console("  >>>>>>>> API UsersControler UpdateUser - _userRepository - good save ");
                    return NoContent();// successful update
                }

            _Logger.LogMsg2Console(">>>>>>>> API UsersControler UpdateUser - _userRepository - bad save ");
               
               return BadRequest("Failed to update user");     // UNsuccessful update

        }




        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file) 
        {
            _Logger.LogMsg2Console("API UsersControler AddPhoto - Start ");
            
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername() );

            var result = await _photoService.AddPhotoAsync(file);

            if(result.Error !=  null)   
            {
                _Logger.LogMsg2Console("API UsersControler AddPhoto - Error 1 ");
                return BadRequest(result.Error.Message);
            }

            _Logger.LogMsg2Console("API UsersControler AddPhoto - create new photo");
            var photo = new Photo {
                Url = result.SecureUrl.AbsoluteUri ,
                PublicId = result.PublicId
            };

            if (user.Photos.Count == 0)
            {
                _Logger.LogMsg2Console("API UsersControler AddPhoto - set IsMain");
                photo.IsMain =  true;
            }

            _Logger.LogMsg2Console("API UsersControler AddPhoto - user.Photos.Add()\n");
            user.Photos.Add(photo);

            if (await _userRepository.SaveAllAsync())
            {
                _Logger.LogMsg2Console("API UsersControler AddPhoto - _userRepository.SaveAllAsync()\n");
                return CreatedAtRoute("GetUser", new {username=user.UserName}  ,  _mapper.Map<PhotoDto>(photo));
            }                

            _Logger.LogMsg2Console("API UsersControler AddPhoto - Error at end ");
            return BadRequest("Problem Adding Photo");
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            _Logger.LogMsg2Console("API UsersControler - SetMainPhoto ");
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername() );

            var photo = user.Photos.FirstOrDefault( x => x.Id == photoId );

            if(photo.IsMain) return BadRequest("This is already your main photo");

            // set current main photo to false
            var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
            if (currentMain != null) 
                currentMain.IsMain = false;

            photo.IsMain = true;

            // save our changes
            if(await _userRepository.SaveAllAsync())
                return NoContent();

            return BadRequest("Failed to set main photo");
        }

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */        
        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        { 
            _Logger.LogMsg2Console("API UsersControler - DeletePhoto ");
            var user =  await _userRepository.GetUserByUsernameAsync(User.GetUsername());    

            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);
            if (photo == null) return NotFound();

            if (photo.IsMain) return BadRequest("You cannot delete your main photo");

            if (photo.PublicId != null) 
            {
                 _Logger.LogMsg2Console("API UsersControler - Deleting Photo in cloud... ");           
                  var result  = await _photoService.DeletePhotoAsync(photo.PublicId);
                  if (result.Error != null) return BadRequest(result.Error.Message );
            } 

            _Logger.LogMsg2Console("API UsersControler - Deleting Photo locally... ");           
            user.Photos.Remove(photo);

            if (await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to delete photo");

        }



        // api/users/3
       /* [Authorize] */
        /*[HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //var user = _context.Users.Find(id);
            //return user;
            Console.WriteLine("\n\nAPI UsersControler GetUsers - ID: " + id.ToString());           
            //return await  _context.Users.FindAsync(id);
            return Ok(await _userRepository.GetUserByIdAsync(id));  
        }
        */
    }
}
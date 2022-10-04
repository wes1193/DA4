// pasted from https://jsonformatter.org/json-to-typescript

import{Photo} from './photo';

export interface Member {
    id:         number;
    username:   string;
    photoUrl:   string;    
    age:        number;
    knownAs:    string;
    created:    Date;
    lastActive: Date;
    gender:     string;
    lookingFor: string;
    interests:  string;
    city:       string;
    country:    string;
    phone:      string;
    email:      string;
    description: string;
    introduction: string;
    photos:     Photo[];    
}


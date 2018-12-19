import { Photo } from './Photo';

export interface User {
    id: number;
    userName: string;
    age: number;
    gender: string;
    knownAs: string;
    created: Date;
    lastActive: Date;
    photoUrl: string;
    city: string;
    country: string;
    interests?: string;
    introduction?: string;
    lookingFor?: string;
    photos?: Photo[];
    roles?: string[];
}

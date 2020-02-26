import { MovieArtist } from './movieArtist';

export class Artist {
    id: number;
    artistName: string;
    realName: string;
    birthdate: Date;
    deathdate: string;
    birthplace: string;
    height: number;
    bio: string;
    pictureUrl: string;
    movies: MovieArtist;
}

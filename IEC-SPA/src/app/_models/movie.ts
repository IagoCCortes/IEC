export interface Movie {
    id: number;
    title: string;
    plot: string;
    runtime: number;
    releaseDate: Date;
    created: Date;
    posterUrl: string;
    genres: string[];
    stars: string[];
    directors: string[];
    writers: string[];
}

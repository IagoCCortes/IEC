export interface UserMovie {
    userProfileId: number;
    MovieId: number;
    review: string;
    rating?: number;
    favorited: boolean;
    userProfileMovieStatusId: number;
}

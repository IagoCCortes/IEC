export interface UserMovie {
    userProfileId: number;
    id: number;
    title: string;
    review: string;
    rating?: number;
    favorited: boolean;
    posterUrl: string;
    userProfileMovieStatusId: number;
}

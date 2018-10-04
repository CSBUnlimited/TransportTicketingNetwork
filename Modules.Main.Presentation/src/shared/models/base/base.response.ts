
export interface BaseResponse {
    isSuccess: boolean;
    status: number;
    responseDateTime?: Date;
    errorMessage?: string;
}
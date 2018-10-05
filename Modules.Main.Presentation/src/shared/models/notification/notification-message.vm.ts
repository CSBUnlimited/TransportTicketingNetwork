
export interface NotificationMessageVM {
    title?: string;
    message: string;
    severity: NotifictionTypes;
    lifeTime?: number;
    isSticky?: boolean;
}

export enum NotifictionTypes {
    Success = 'success',
    Information = 'info',
    Warning = 'warn',
    Error = 'error'
}
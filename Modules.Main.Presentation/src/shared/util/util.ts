import { NotificationMessageVM, NotifictionTypes } from "../models";
import { GlobalEventConstants } from "../consts";

export class Util {

    /**
     * Check whether given array has elements or not
     * @param array Array need to check
     * @returns True if has elements
     */
    public static isArrayHasElements(array?: any[]): boolean {
        return Boolean(array && array.length > 0);
    }

    /**
     * Can push message or notification according to details
     * @param messageDeatils Message Details
     */
    public static pushNotificationMessages(messageDeatils: NotificationMessageVM): void {

        let title: string = '';

        if (messageDeatils.severity == NotifictionTypes.Information) {
            title = 'Infomation';
        }
        else if (messageDeatils.severity == NotifictionTypes.Success) {
            title = 'Success';
        }
        else if (messageDeatils.severity == NotifictionTypes.Warning) {
            title = 'Warning';
        }
        else {
            title = 'Error';
        }

        if (!messageDeatils.title) {
            messageDeatils.title = title;
        }

        if (!messageDeatils.lifeTime || messageDeatils.lifeTime <= 0) {
            messageDeatils.lifeTime = (messageDeatils.severity == NotifictionTypes.Success) ? 3000 : 5000;
        }

        messageDeatils.isSticky = Boolean(messageDeatils.isSticky);

        let messageEvent: CustomEvent = new CustomEvent(GlobalEventConstants.Notification, { detail: messageDeatils });
        window.dispatchEvent(messageEvent);
    }
}
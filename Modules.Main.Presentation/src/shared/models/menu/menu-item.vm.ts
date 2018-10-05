import { UserLevel } from "../user";

export interface MenuItemVM {
    label: string;
    icon: string;
    showFor: UserLevel[];
    badge?: string;
    items?: MenuItemVM[];
    isDisabled?: boolean;
    isOutsideURL?: boolean;
    url?: string;
    target?: '_blank' | '_self' | '_parent' | '_top';
    command?: (menuItem: MenuItemVM) => void;
}
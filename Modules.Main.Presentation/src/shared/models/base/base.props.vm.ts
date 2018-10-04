import { ReactNode } from 'react';
import * as History from 'history'
import { match, StaticContext } from 'react-router';

export interface BasePropsVM<LocationState = History.LocationState, MatchParams = any, StaticContextExt extends StaticContext = StaticContext> {
    history?: History.History;
    location?: History.Location<LocationState>;
    match?: match<MatchParams>;
    staticContext?: StaticContextExt;
    
    children?: ReactNode | ReactNode[] | any;
}
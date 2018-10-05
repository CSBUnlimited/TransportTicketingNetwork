import * as React from 'react';
import * as ReactDOM from 'react-dom';
import AppComponent from './components/AppComponent';
import registerServiceWorker from './registerServiceWorker';
import { HashRouter } from 'react-router-dom';

import 'bootstrap/dist/css/bootstrap.css';
import 'font-awesome/css/font-awesome.css';
import 'primereact/resources/themes/nova-light/theme.css';
import 'primereact/resources/primereact.min.css';
import 'primeicons/primeicons.css';
import 'primeflex/primeflex.css';
import './index.css';
import ScrollToTop from './shared/components/hoc/ScrollToTop';

ReactDOM.render(
    <HashRouter>
        <ScrollToTop>
            <AppComponent />
        </ScrollToTop>
    </HashRouter>
    ,
    document.getElementById('root') as HTMLElement
);
registerServiceWorker();

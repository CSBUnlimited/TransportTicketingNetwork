import * as React from 'react';
import './FooterLayout.css';

export const FooterLayout = () => {
    return (
        <div className="layout-footer text-center">
            <img src="favicon.ico" className="footer-logo_FooterLayout" />
            <span className="footer-text footer-company-name_FooterLayout">Transport Ticketing Network</span>
            <span className="footer-text">&copy; 2018</span>
        </div>
    );
}
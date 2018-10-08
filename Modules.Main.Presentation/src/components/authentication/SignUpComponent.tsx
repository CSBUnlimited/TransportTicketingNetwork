import * as React from 'react';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';

export default class SignUpComponent extends React.Component {


    render() {
        return (
            <div className="p-grid p-fluid">
                <div className="p-col-12">
                    <div className="card card-w-title">
                        <h1>Signup</h1>
                        <div className="p-grid">
                            <div className="p-col-12 p-md-6">
                                <InputText placeholder="Username" />
                            </div>
                            <div className="p-col-12 p-md-6">
                                <InputText placeholder="First Name" />
                            </div>
                            <div className="p-col-12 p-md-6">
                                <InputText placeholder="Last Name" />
                            </div>
                            <div className="p-col-12 p-md-6">
                                <InputText placeholder="Address" />
                            </div>
                            {/* <div className="p-col-12 p-md-6">
                                <InputText placeholder="Disabled" disabled={true} />
                            </div>
                            <div className="p-col-12 p-md-6">
                                <InputText placeholder="Error" className="p-error" />
                            </div> */}
                        </div>

                        <hr />

                        <div className="p-grid">
                            <div className="p-col-12">
                                <div className="p-col-12 p-md-4 pull-right" style={{ textAlign: 'center' }}>
                                    <Button label="Signup" style={{ marginBottom: '10px' }} className="" />
                                    <Button label="Login" style={{ marginBottom: '10px' }} className="p-button-secondary" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

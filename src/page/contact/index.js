import React, { Component } from 'react';
// import axios from 'axios';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Contact.css';

class Contact extends Component {
    constructor(props) {
        super(props);
        this.state = {
            form: {
                username: '',
                email: '',
                message: '',
                // successMessage: '',
                // errorMessage: '',
            },
            error: {

            },
        };
    }
    handleChange = (e) => {
        const data = { ...this.state.form }
        console.log(data);
        data[e.target.name] = e.target.value;
        this.setState({
            form: data,
        });
    };
    handleSubmit = (e) => {
        e.preventDefault();
        const { username, email, message } = this.state.form;

        const error = {};
        if (typeof username === "string" && username.trim() === "") {
            error.username = 'UserName Không Được Để Trống!';
          
        }
        if (typeof email === "string" && email.trim() === "") {
            error.email = 'Email Không Được Để Trống!';
        }
        if (typeof message === "string" && message.trim() === "") {
            error.message = 'Message Không Được Để Trống!';
        }
        this.setState({
            error: error,
        })
        if (Object.keys(error).length === 0) {
            this.setState({
                form: {
                    username: "",
                    email: "",
                    message: "",
                }
            })
        }
    };
    render() {
        const { form, error } = this.state;
        console.log(error);
        const position = [21.03546, 105.81887];

        return (

            <div className='container py-5'>

                <div className='map row justify-content-center'>
                    <div className='image col-md-6'>
                        <div className=''>
                            <h1>Get In touch width our lovely team</h1>
                        </div>
                        <div className='mt-4'>
                            <h6>Yoora Teachnologies</h6>
                        </div>

                        <p className='mb-2'>2203 Teuku Umar.Kartini .NG 959006 .Indonesia</p>
                        <MapContainer className='MapContainers' center={position} zoom={15} >

                            <TileLayer
                                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                                attribution='&copy; <a href="https://www.openstreetmap.org/directions#map=19/21.03546/105.81887">GoogleMap</a> contributors'
                            />
                            <Marker position={position}>
                                <Popup>Vị trí 285 Đội Cấn</Popup>
                            </Marker>
                        </MapContainer>
                        <div className='row'>
                            <div className='col-4'>
                                <div className=''>
                                    <div className=''>
                                        <h2>General</h2>
                                        <p>hello@aptech.com</p>
                                    </div>
                                </div>
                            </div>
                            <div className='col-8'>
                                <h2>Support</h2>
                                <p>support@gmail.com</p>
                            </div>
                        </div>

                    </div>


                    <div className="col-md-6 mt-5">
                        {
                            Object.keys(error).length > 0 && <div className="alert alert-danger text-center">Vui lòng kiểm tra lại dữ liệu</div>
                        }
                        <div></div>
                        <form action="" className='contact py-5' onSubmit={this.handleSubmit}>
                            <div className="mb-4">

                                <input type="text" id='username' name='username' value={form.username} onChange={this.handleChange} className={`py-4 form-control ${error.username ? "is-invalid" : ""} `} placeholder='Your Name' />
                                {error.username && (
                                    <div className="invalid-feedback">{error.username}</div>
                                )}
                            </div>
                            <div className="mb-4">

                                <input type="email" id='email' name='email' value={form.email} onChange={this.handleChange} className={`py-4 form-control ${error.email ? "is-invalid" : ""}`} placeholder='Your Email' />
                                {error.email && (
                                    <div className="invalid-feedback">
                                        {error.email}
                                    </div>
                                )}

                            </div>
                            <div className="mb-4">
                                <textarea rows={5} type="text" id='message' name='message' value={form.message} onChange={this.handleChange} className={`form-control ${error.message ? "is-invalid" : ""}`} placeholder='Message'  >
                                </textarea>
                                {error.message && (
                                    <div className="invalid-feedback">
                                        {error.message}
                                    </div>
                                )}
                            </div>
                            <button type='submit' className='btn btn-lg btn-success '>Send Message</button>
                        </form>
                        {/* 1  <p className="success-message">{form.successMessage}</p>
                      2  <p className="error-message">{form.errorMessage}</p> */}
                    </div>


                </div>
                <div className='row'>
                    <div className='col-4 my-5 py-5'>
                        <h3>Our Clients and partners</h3>
                    </div>
                    <div className='col-8 py-5'>
                        <div className='row'>
                            <div className="enter-image col-sm-1.6">
                                <img src="./images/adidas.jpg" alt=""
                                />
                            </div>
                            <div className="enter-image col-sm-1.6">
                                <img src="./images/Cocacola.png" alt=""
                                />
                            </div>
                            <div className="enter-image col-sm-1.6">
                                <img src="./images/google.png" alt=""
                                />
                            </div>
                            <div className="enter-image col-sm-1.6">
                                <img src="./images/Microsoft.png" alt=""
                                />
                            </div>
                            <div className="enter-image col-sm-1.6">
                                <img src="./images/vinmark.jpg" alt=""
                                />
                            </div>
                        </div>
                    </div>
                    <hr></hr>
                </div>
            </div>

        );

    }
}

export default Contact;
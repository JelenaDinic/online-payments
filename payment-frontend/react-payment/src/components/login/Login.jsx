import { useState } from 'react';
import './Login.css';
import backend from '../../api/backend'
import { useNavigate } from 'react-router'

export default function Login() {
    const [user, setUser] = useState({ Email: '', Password: '' });
    const navigate = useNavigate();

    const login = async () => {
        try {
            const response = await backend.post('/User/login', user);
            localStorage.setItem('token', response.data.token);
            window.confirm("User is successfully logged-in");
            navigate("/profile");
        } catch (error) {
            alert(error);
        }
    }

    return (
        <>
            <section className="vh-100">
                <div className="container-fluid">
                    <div className="row">
                        <div className="col-sm-6 text-black">

                            <div className="px-5 ms-xl-4">
                                <span className="h2 fw-bold ">Online payment application</span>
                            </div>
                            <div className="d-flex align-items-center h-custom-2 px-5 ms-xl-4 pt-xl-0 mt-xl-n5">

                                <form>

                                    <h3 className="fw-normal mb-3 pb-3" >LOG IN</h3>

                                    <div className="form-outline mb-4">
                                        <input type="email" id="form2Example18" className="form-control form-control-lg" onChange={(e) => setUser(prevState => ({ ...prevState, Email: e.target.value}))}/>
                                        <label className="form-label" htmlFor="form2Example18">Email address</label>
                                    </div>

                                    <div className="form-outline mb-4">
                                        <input type="password" id="form2Example28" className="form-control form-control-lg" onChange={(e) => setUser(prevState => ({ ...prevState, Password: e.target.value}))}/>
                                        <label className="form-label" htmlFor="form2Example28">Password</label>
                                    </div>

                                    <div className="pt-1 mb-4">
                                        <button className="btn btn-info btn-lg btn-block" type="button" onClick={(e) => login(e)}>Login</button>
                                    </div>
                                    <p>Don't have an account? <a href="/registration" className="link-info">Register here</a></p>

                                </form>

                            </div>

                        </div>
                        <div className="col-sm-6 px-0 d-none d-sm-block">
                            <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/img3.webp"
                                alt="Login image" className="w-100 vh-100" />
                        </div>
                    </div>
                </div>
            </section>
        </>
    )
}
import { useState } from "react";
import backend from "../../api/backend";
import { useNavigate } from 'react-router'

export default function Registration() {
    const [user, setUser] = useState({ name: '', lastname: '', phoneNumber: '', email: '', password: '' });
    const [confirmedPassword, setConfirmedPassword] = useState("")
    const navigate = useNavigate();

    const register = async () => {
        if(validatePasswords()) {
            try {
                const response = await backend.post('/User/', user);
                window.confirm("User is successfully registered");
                navigate("/login");
            } catch (error) {
                alert(error);
            }
        } else {
            alert("Passwords do not match!")
        }
        
    }
    const validatePasswords = () => {
        if(user.password === confirmedPassword)
            return true
        else 
            return false
    }
    
    return (
        <>
            <div className="row">
                <div className="col-xl-8">
                    <div className="card mb-4">
                        <div className="card-header">Sign Up</div>
                        <div className="card-body">
                            <form>
                                <div className="row gx-3 mb-3">
                                    <div className="col-md-6">
                                        <label className="small mb-1" htmlFor="inputFirstName">Name</label>
                                        <input className="form-control" id="inputFirstName" type="text" placeholder="Enter your first name" onChange={(e) => setUser(prevState => ({ ...prevState, name: e.target.value }))}/>
                                    </div>
                                    <div className="col-md-6">
                                        <label className="small mb-1" htmlFor="inputLastName">Lastname</label>
                                        <input className="form-control" id="inputLastName" type="text" placeholder="Enter your last name" onChange={(e) => setUser(prevState => ({ ...prevState, lastname: e.target.value }))}/>
                                    </div>
                                </div>
                                <div className="col-md-6">
                                    <label className="small mb-1" htmlFor="inpu[Phone]">Phone number</label>
                                    <input className="form-control" id="inputPhone" type="text" placeholder="Enter your phone number" onChange={(e) => setUser(prevState => ({ ...prevState, phoneNumber: e.target.value }))} />
                                </div>
                                <div className="col-md-6 mb-3">
                                    <label className="small mb-1" htmlFor="inputEmail">Email address</label>
                                    <input className="form-control" id="inputEmail" type="email" placeholder="Enter your email" onChange={(e) => setUser(prevState => ({ ...prevState, email: e.target.value }))} />
                                </div>
                                <div className="col-md-6 mb-3">
                                    <label className="small mb-1" htmlFor="inputEmail">Password</label>
                                    <input className="form-control" id="inputEmail" type="password" placeholder="Enter your email" onChange={(e) => setUser(prevState => ({ ...prevState, password: e.target.value }))} />
                                </div>
                                <div className="col-md-6 mb-3">
                                    <label className="small mb-1" htmlFor="inputEmail">Confirm Password</label>
                                    <input className="form-control" id="inputEmail" type="password" placeholder="Enter your email" onChange={(e) => setConfirmedPassword(e.target.value)} />
                                </div>
                            
                                <button className="btn btn-primary" type="button" onClick={(e) => register(e)}>Sign Up</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
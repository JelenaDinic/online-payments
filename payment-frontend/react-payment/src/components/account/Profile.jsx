import { useEffect, useState } from "react";
import './Profile.css';
import backend from "../../api/backend";
import { useNavigate } from 'react-router'
import UpdateBudgetModal from "./updateBudgetModal/UpdateBudgetModal";

export default function Profile() {

    const [user, setUser] = useState(null);
    const [displayModal, setDisplayModal] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        let token = localStorage.getItem('token');
        let id;
        if (token != null) {
            let decodedJWT = JSON.parse(window.atob(token.split('.')[1]));
            id = decodedJWT.UserId;
        }
        backend.get("/User/" + id)
            .then((response) => {
                setUser(response.data)
            })

    }, [])
    const changeUser = async () => {
        try {
            const response = await backend.put('/User/' + user.id, user);
            window.confirm("Your profile is successfully updated");
            navigate("/profile");
        } catch (error) {
            alert(error);
        }
    }


    return (
        <>
            {
                user === null ?
                    <div className='loading'>Loading . . .</div> :
                    <div className="row">
                        <div className="col-xl-4">

                            <div className="card mb-4 mb-xl-0">
                                <div className="card-header">Profile Picture</div>
                                <div className="card-body text-center">
                                    <img className="img-account-profile rounded-circle mb-2" src="https://t3.ftcdn.net/jpg/03/46/83/96/360_F_346839683_6nAPzbhpSkIpb8pmAwufkC7c5eD7wYws.jpg" alt="" />
                                    <br />
                                    <button className="btn btn-primary" type="button">Upload new image</button>
                                </div>
                            </div>
                        </div>
                        <div className="col-xl-8">
                            <div className="card mb-4">
                                <div className="card-header">Account Details</div>
                                <div className="card-body">
                                    <form>
                                        <div className="row gx-3 mb-3">
                                            <div className="col-md-6">
                                                <label className="small mb-1" htmlFor="inputFirstName">Name</label>
                                                <input className="form-control" id="inputFirstName" type="text" placeholder="Enter your first name" value={user.name} onChange={(e) => setUser(prevState => ({ ...prevState, name: e.target.value }))} />
                                            </div>
                                            <div className="col-md-6">
                                                <label className="small mb-1" htmlFor="inputLastName">Lastname</label>
                                                <input className="form-control" id="inputLastName" type="text" placeholder="Enter your last name" value={user.lastname} onChange={(e) => setUser(prevState => ({ ...prevState, lastname: e.target.value }))} />
                                            </div>
                                        </div>
                                        <div className="col-md-6">
                                            <label className="small mb-1" htmlFor="inpu[Phone]">Phone number</label>
                                            <input className="form-control" id="inputPhone" type="text" placeholder="Enter your phone number" value={user.phoneNumber} onChange={(e) => setUser(prevState => ({ ...prevState, phoneNumber: e.target.value }))} />
                                        </div>
                                        <div className="col-md-6 mb-3">
                                            <label className="small mb-1" htmlFor="inputEmail">Email address</label>
                                            <input className="form-control" id="inputEmail" type="email" placeholder="Enter your email" value={user.email} onChange={(e) => setUser(prevState => ({ ...prevState, email: e.target.value }))} />
                                        </div>
                                        <div className="budget">
                                            <strong ><label className="bdg-lbl" >BUDGET </label>
                                                <label className="bdg-amnt">{user.budget},00</label>
                                                <label className="bdg-cur">RSD</label>
                                            </strong>
                                            <br></br>
                                            <button 
                                                className="btn btn-primary" 
                                                onClick={(e) => {
                                                    e.preventDefault();
                                                    setDisplayModal(true)
                                                }}
                                            > 
                                                Add 
                                            </button>
                                        </div>
                                        <button className="btn btn-primary" type="button" onClick={(e) => changeUser(e)}>Save changes</button>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
            }
            {
                displayModal && (
                    <UpdateBudgetModal setDisplayModal={setDisplayModal}/>
                )
            }
        </>
    )
}
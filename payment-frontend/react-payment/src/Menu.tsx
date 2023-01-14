import { useEffect, useState } from "react";
import { NavLink, useNavigate } from "react-router-dom";

export default function Menu() {
    const [token, setToken] = useState(localStorage.getItem('token'))
    const navigate = useNavigate();

    const logOut = () => {
        localStorage.removeItem('token');
    }

    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <NavLink className="navbar-brand" to="/">Online Payment Application</NavLink>
                <div className="collapse navbar-collapse">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        {token !== null ?
                            <><li className="nav-item">
                                <NavLink className="nav-link" to="/transaction-history">
                                    Transaction History
                                </NavLink>
                            </li><li className="nav-item">
                                    <NavLink className="nav-link" to="/profile">
                                        Account
                                    </NavLink>
                                </li><li className="nav-item">
                                    <NavLink className="nav-link" to="/money-transfer">
                                        Money Transfer
                                    </NavLink>
                                </li><li className="nav-item">
                                    <NavLink className="nav-link" to="/exchange-rate">
                                        Exchange rate
                                    </NavLink>
                                </li>
                                <li className="nav-item">
                                    <NavLink className="nav-link" to="/login" onClick={(e) => logOut()}>
                                        Logout
                                    </NavLink>
                                </li></> : <><li className="nav-item">
                                    <NavLink className="nav-link" to="/login">
                                        Login
                                    </NavLink>
                                </li></>
                        }
                    </ul>
                </div>
            </div>
        </nav>
    )
}
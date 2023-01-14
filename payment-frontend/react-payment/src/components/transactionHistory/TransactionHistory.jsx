import { useEffect, useState } from "react";
import backend from "../../api/backend";
export default function TrancationHistory() {
    const [transactions, setTransactions] = useState([]);

    useEffect(() => {
        let token = localStorage.getItem('token');
        let id;
        if (token != null) {
            let decodedJWT = JSON.parse(window.atob(token.split('.')[1]));
            id = decodedJWT.UserId;
        }
        backend.get("/Transaction/" + id)
            .then((response) => {
                setTransactions(response.data)
            })

    }, [])

    return (
        <>
            <div className="row">
                <div className="col-xl-8">
                    <div className="card mb-4 mt-4">
                        <div className="card-header">Transaction History</div>
                        <div className="card-body">
                            <div className="table-responsive">
                                <table className="table">
                                    <thead>
                                        <tr>
                                            <th>Amount</th>
                                            <th>Recipient</th>
                                            <th>Date and time</th>
                                        </tr>
                                    </thead>
                                    {transactions.map(transaction => (
                                        <tbody key={transaction.id}>
                                            <tr >
                                                {transaction.recipientEmail === "own" ?
                                                    <td>{transaction.amount}</td> :
                                                    <td>-{transaction.amount}</td>
                                                }

                                                <td>{transaction.recipientEmail === 'own' ? '' : transaction.recipientEmail}</td>
                                                <td>{transaction.dateTime}</td>

                                            </tr>
                                        </tbody>
                                    ))}
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
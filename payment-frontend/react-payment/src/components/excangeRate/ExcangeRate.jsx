import './ExchangeRate.css';
import { useEffect, useState } from "react";
import backend from "../../api/backend";
export default function ExchangeRate() {
    const [currencies, setCurrencies] = useState([]);
    const [selected, setSelected] = useState([{id: "EUR", rate: 117.36}]);
    const [converted, setConverted] = useState(0);

    useEffect(() => {
        fetchCurrencies();
    })

    useEffect(() => {
        if(selected.length) {
            setConverted(converted/selected[0].rate)
        }
    }, [selected])

    const fetchCurrencies = async () => {
        try {
            const response = await backend.get('/Currency/')
            setCurrencies(response.data);
        } catch (error) {
            alert(error);
        }
    }

    return (
        <>
            <div className="row">
                <div className="col-xl-8">
                    <div className="card mb-4 mt-4">
                        <div className="card-header">Convert currency</div>
                        <div className="card-body">
                            <form>
                                <div className="row gx-3 mb-3">
                                    <div className="col-md-6">
                                        <label className="small mb-1 pd-10" >Amount</label>
                                        <label className="small mb-1">Currency</label>
                                    </div>
                                    <br />
                                    <div className="rsd">
                                        <input className="amount-input" type="number" placeholder="Enter amount" onChange={(amount) => setConverted(amount.target.value/selected[0].rate)}/>
                                        <input className="rsd-input" type="text" value="RSD" disabled />
                                    </div>
                                    <br />
                                    <div className="another-curr">
                                        <input className="amount-input" value={converted} type="text" placeholder="Converted" disabled />
                                        <select onChange={(e) => setSelected(currencies.filter((item) => item.id === e.target.value))}>
                                            {currencies.map((item) => (
                                                <option key={item.id}>{item.id}</option>
                                            ))}
                                        </select>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
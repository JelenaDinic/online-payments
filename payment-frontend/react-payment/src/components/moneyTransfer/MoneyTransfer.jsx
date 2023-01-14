import { useState } from "react";
import backend from "../../api/backend";
import { loadStripe } from '@stripe/stripe-js';
import { Elements, CardElement, ElementsConsumer } from '@stripe/react-stripe-js';

export default function MoneyTransfer() {
    const stripePromise = loadStripe('pk_test_51K1AwBDCC8Upr6zGBGJgTROKSrHAsTlOWfiW0C1JOwgfippNLjk9ySMl6rBr394h0YZaNtpm5KBB5phA6yEfToCS00ILny4O0w');
    const [amount, setAmount] = useState(0);
    const [email, setEmail] = useState("");
    const [oldBudget, setOldBudget] = useState(0) 

    const send = async (e, elements, stripe) => {
        e.preventDefault();
        const cardElement = elements.getElement(CardElement);
        const { error } = await stripe.createPaymentMethod({ type: 'card', card: cardElement });

        if (error) {
            alert(error.message)
        } else {
            let token = localStorage.getItem('token');
            let id;
            if (token != null) {
                let decodedJWT = JSON.parse(window.atob(token.split('.')[1]));
                id = decodedJWT.UserId;
                setOldBudget(decodedJWT.Budget)
            }
            if(validate()){
                backend.post("/Transaction/", { userId: id, recipientEmail: email, amount: amount })
                .then((response) => {
                    alert("Money is successfully transfered!")
                })
            }
            else{
                alert("You do not have that amount of money on your account!")
            }
            
        }
    }
    const validate = () => {
        if(oldBudget < amount)
            return false
        else
            return true
    }

    return (
        <>
            <div className="row">
                <div className="col-xl-8">
                    <div className="card mb-4 mt-4">
                        <div className="card-header">Money Transfer</div>
                        <div className="card-body">
                            <Elements stripe={stripePromise}>
                                <ElementsConsumer>
                                    {({ elements, stripe }) => (
                                        <form onSubmit={(e) => send(e, elements, stripe)} className='ccForm'>
                                            <input type="text" placeholder='Amount (RSD)' onChange={(e) => setAmount(e.target.value)} />
                                            <input type="email" placeholder='Recipient email' onChange={(e) => setEmail(e.target.value)} />
                                            <p>Enter your credit card informations</p>
                                            <CardElement required />
                                            <br />
                                            <button className="btn btn-primary" type="submit">
                                                Send
                                            </button>
                                        </form>
                                    )}
                                </ElementsConsumer>
                            </Elements>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
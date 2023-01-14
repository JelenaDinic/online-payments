import Profile from "./components/account/Profile";
import ExchangeRate from "./components/excangeRate/ExcangeRate";
import Login from "./components/login/Login";
import MoneyTransfer from "./components/moneyTransfer/MoneyTransfer";
import Registration from "./components/registration/Registration";
import TransactionHistory from "./components/transactionHistory/TransactionHistory";

const routes = [
    {path: '/', component: Login, exact: true},
    {path: '/profile', component: Profile},
    {path: '/exchange-rate', component: ExchangeRate},
    {path: '/registration', component: Registration},
    {path: '/transaction-history', component: TransactionHistory},
    {path: '/money-transfer', component: MoneyTransfer},
    {path: '*', component: Login}

]

export default routes;
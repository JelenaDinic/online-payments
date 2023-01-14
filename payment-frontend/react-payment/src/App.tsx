import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Menu from './Menu';
import routes from './route-config';

function App() {
  return (
    <BrowserRouter>
      <Menu/>
      <div className='container'>
        <Routes>
        {routes.map(route => 
            <Route key={route.path} path={route.path} element={<route.component />}>
            </Route>
            )}
        </Routes>
      </div>
    </BrowserRouter>


  )
}

export default App;

import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import publicRoutes from './routes';
import DefaultLayout from './components/Layout/DefaultLayout';
import './components/GlobalStyles/GlobalStyles.scss';

function App() {
  return (
    <Router>
      <Routes>
        {publicRoutes.map((route, index) => {
          let Layout = DefaultLayout 
          return <Route key={index} path={route.path} element={<Layout>{route.component}</Layout>}/>
        })}
      </Routes>
    </Router>
  );
}

export default App;

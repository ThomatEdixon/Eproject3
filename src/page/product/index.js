import SideBar from './Sidebar';
import ListProduct from './ListProduct';

function Product() {
    return (
        <div>
            <div className="container-fluid mt-5 mb-5" style={{ maxWidth: '93%' }}>
                <div className='row'>
                    <SideBar />
                    <ListProduct />
                </div>
            </div>
        </div>
    );
}

export default Product;

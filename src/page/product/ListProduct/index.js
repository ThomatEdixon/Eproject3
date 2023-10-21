import { Grid3x3GapFill } from 'react-bootstrap-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faGripVertical, faList, faXmark } from '@fortawesome/free-solid-svg-icons';
import ProductItem from '../../../components/ProductItem';
import { ListProductCssModule } from '../../../CssModule';

const cx = ListProductCssModule()

function ListProduct() {
    return (
        <div className={cx('wrapper', 'col-9')}>
            <div className={cx('content')}>
                <div className={cx('top-bar')}>
                    <div className={cx('sorting')}>
                        <div className={cx('result-count')}>
                            <span>Showing the single result</span>
                        </div>

                        <div className={cx('sorting-bar')}>
                            <div className={cx('product-per-row')}>
                                <FontAwesomeIcon className={cx('icon')} icon={faGripVertical} />
                                <Grid3x3GapFill className={cx('icon')} />
                                <FontAwesomeIcon className={cx('icon')} icon={faList} />
                            </div>

                            <div className={cx('sort-type')}>
                                <select className="">
                                    <option>default sorting</option>
                                    <option>sort by popularity</option>
                                    <option>sort by average rating</option>
                                    <option>sort by latest</option>
                                    <option>sort by price: low to high</option>
                                    <option>sort by price: high to low</option>
                                </select>
                            </div>
                        </div>
                    </div>

                    <div className={cx('filters')}>
                        <span>
                            green
                            <FontAwesomeIcon className={cx('icon')} icon={faXmark} />
                        </span>
                        <button className={cx('hover-default-text')}>clear all</button>
                    </div>
                </div>

                <div className={cx('product-list', 'row')}>
                    <div className="col-4">
                        <ProductItem />
                    </div>
                    <div className="col-4">
                        <ProductItem />
                    </div>
                    <div className="col-4">
                        <ProductItem />
                    </div>
                    <div className="col-4">
                        <ProductItem />
                    </div>
                    <div className="col-4">
                        <ProductItem />
                    </div>
                </div>

                <div className={cx('product-loading')}></div>
            </div>
        </div>
    );
}

export default ListProduct;

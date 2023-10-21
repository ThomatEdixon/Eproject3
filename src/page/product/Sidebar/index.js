import Slider from 'rc-slider';
import 'rc-slider/assets/index.css';
import { useState } from 'react';
import { SidebarCssModule } from '../../../CssModule';

const cx = SidebarCssModule();

function SideBar() {
    const [priceFilter, setPriceFilter] = useState(100);

    const handlePriceFilter = (currentPrice) => {
        console.log(currentPrice);
        setPriceFilter(currentPrice);
    };

    return (
        <div className={cx('wrapper', 'col-3')}>
            <div className={cx('content')}>
                <aside>
                    <div className={cx('siderbar-filter', { 'sidebar-filter-category': true })}>
                        <h3 className={cx('title')}>categories</h3>
                        <div className={cx('main')}>
                            <ul className="list-group">
                                <li className="list-group-item border-0 text-capitalize">
                                    <span className={cx('cat_name')}>bath & body</span>
                                    <span className={cx('cat_count')}>9</span>
                                </li>
                                <li className="list-group-item border-0 text-capitalize">
                                    <span className={cx('cat_name')}>brushes</span>
                                    <span className={cx('cat_count')}>9</span>
                                </li>
                                <li className="list-group-item border-0 text-capitalize">
                                    <span className={cx('cat_name')}>hair</span>
                                    <span className={cx('cat_count')}>9</span>
                                </li>
                                <li className="list-group-item border-0 text-capitalize">
                                    <span className={cx('cat_name')}>lips</span>
                                    <span className={cx('cat_count')}>9</span>
                                </li>
                                <li className="list-group-item border-0 text-capitalize">
                                    <span className={cx('cat_name')}>makeup</span>
                                    <span className={cx('cat_count')}>9</span>
                                </li>
                                <li className="list-group-item border-0 text-capitalize">
                                    <span className={cx('cat_name')}>skincare</span>
                                    <span className={cx('cat_count')}>9</span>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div className={cx('siderbar-filter', { 'sidebar-filter-price': true })}>
                        <h3 className={cx('title')}>price</h3>
                        <div className={cx('main')}>
                            <div className={cx('slider-price')}>
                                <Slider
                                    defaultValue={priceFilter}
                                    min={0}
                                    max={100}
                                    railStyle={{ display: 'none' }}
                                    trackStyle={{ backgroundColor: 'black', height: 2 }}
                                    handleStyle={{
                                        width: '12px',
                                        height: '12px',
                                        border: '2px solid #000',
                                        backgroundColor: '#fff',
                                        borderRadius: '0',
                                    }}
                                    onChange={(value) => handlePriceFilter(value)}
                                />
                            </div>
                            <div className={cx('price-input')}>
                                <span className={cx('price-filter-label')}>range : </span>
                                <span className={cx('price-filter-text')}>$0</span> -
                                <span className={cx('price-filter-text')}> ${priceFilter}</span>
                            </div>
                        </div>
                    </div>
                    <div className={cx('siderbar-filter', { 'sidebar-filter-color': true })}>
                        <h3 className={cx('title')}>color</h3>
                        <div className={cx('main', { 'filter-color-product': true })}>
                            <ul className="list-group">
                                <li className="list-group-item border-0 text-capitalize">blue</li>
                                <li className="list-group-item border-0 text-capitalize">green</li>
                                <li className="list-group-item border-0 text-capitalize">orange</li>
                                <li className="list-group-item border-0 text-capitalize">pink</li>
                                <li className="list-group-item border-0 text-capitalize">red</li>
                            </ul>
                        </div>
                    </div>
                    <div className={cx('siderbar-filter', { 'sidebar-filter-brand': true })}>
                        <h3 className={cx('title')}>brands</h3>
                        <div className={cx('main')}>
                            <ul className="row row-cols-2 p-0 g-0">
                                <li className="list-group-item col-4 text-center mb-3 me-3">
                                    <input className='d-none' type='checkbox' id='brand1' />
                                    <label for="brand1">
                                        <img width={100} src="https://wpbingosite.com/wordpress/cerla/wp-content/uploads/2021/02/brand-1.jpg" />
                                    </label>
                                </li>
                                <li className="list-group-item col-4 text-center mb-3 me-3">
                                    <input className='d-none' type='checkbox' id='brand2' />
                                    <label for="brand2">
                                        <img width={100} src="https://wpbingosite.com/wordpress/cerla/wp-content/uploads/2021/02/brand-2.jpg" />
                                    </label>
                                </li>
                                <li className="list-group-item col-4 text-center mb-3 me-3">
                                    <input className='d-none' type='checkbox' id='brand3' />
                                    <label for="brand3">
                                        <img width={100} src="https://wpbingosite.com/wordpress/cerla/wp-content/uploads/2021/02/brand-3.jpg" />
                                    </label>
                                </li>
                                <li className="list-group-item col-4 text-center mb-3 me-3">
                                    <input className='d-none' type='checkbox' id='brand4' />
                                    <label for="brand4">
                                        <img width={100} src="https://wpbingosite.com/wordpress/cerla/wp-content/uploads/2021/02/brand-4.jpg" />
                                    </label>
                                </li>
                                <li className="list-group-item col-4 text-center mb-3 me-3">
                                    <input className='d-none' type='checkbox' id='brand5' />
                                    <label for="brand5">
                                        <img width={100} src="https://wpbingosite.com/wordpress/cerla/wp-content/uploads/2021/02/brand-5.jpg" />
                                    </label>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div className={cx('siderbar-filter', { 'sidebar-filter-feature': true })}>
                        <h3 className={cx('title')}>feature product</h3>
                        <div className={cx('main')}></div>
                    </div>
                </aside>
            </div>
        </div>
    );
}

export default SideBar;

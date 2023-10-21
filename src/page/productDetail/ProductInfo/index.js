import Slider from 'react-slick';
import { TransformWrapper, TransformComponent } from 'react-zoom-pan-pinch';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faStar, faMinus, faPlus } from '@fortawesome/free-solid-svg-icons';
import { faClock, faHeart } from '@fortawesome/free-regular-svg-icons';
import { faFacebook, faInstagram, faLinkedin, faTwitter } from '@fortawesome/free-brands-svg-icons';
import { Link } from 'react-router-dom';
import ReviewProduct from './ReviewProduct';
import TrendingProduct from "../../../components/TrendingProduct"
import { ProductInfoCssModule } from '../../../CssModule';

const cx = ProductInfoCssModule();

function ProductInfo() {
    let imageShow =
        'https://wpbingosite.com/wordpress/cerla/wp-content/webp-express/webp-images/uploads/2020/12/BLUEBERRY-GEL-CLEANSER-1020x1020.jpg.webp';

    const slickConfig = {
        infinite: true,
        slidesToShow: 4,
        slidesToScroll: 1,
        dots: false,
        arrow: true,
    };

    return (
        <div className={cx('wrapper')}>
            <div className={cx('content')}>
                <div className={cx('prd-info', 'container')}>
                    <div className="row">
                        <div className={cx('thumb', 'col-7')}>
                            <div className={cx('prd-image')}>
                                <TransformWrapper>
                                    <TransformComponent>
                                        <img src={imageShow} />
                                    </TransformComponent>
                                </TransformWrapper>
                            </div>

                            <div className={cx('prd-thumbnail')}>
                                <Slider {...slickConfig}>
                                    <div className={cx('thumb-item')}>
                                        <img
                                            className={cx('checked')}
                                            width="100%"
                                            src="https://wpbingosite.com/wordpress/cerla/wp-content/webp-express/webp-images/uploads/2020/12/BLUEBERRY-GEL-CLEANSER-1020x1020.jpg.webp"
                                        />
                                    </div>
                                    <div className={cx('thumb-item')}>
                                        <img
                                            width="100%"
                                            src="https://wpbingosite.com/wordpress/cerla/wp-content/webp-express/webp-images/uploads/2020/12/BLUEBERRY-GEL-CLEANSER3-1020x1020.jpg.webp"
                                        />
                                    </div>
                                    <div className={cx('thumb-item')}>
                                        <img
                                            width="100%"
                                            src="https://wpbingosite.com/wordpress/cerla/wp-content/webp-express/webp-images/uploads/2020/12/BLUEBERRY-GEL-CLEANSER2-1020x1020.jpg.webp"
                                        />
                                    </div>
                                    <div className={cx('thumb-item')}>
                                        <img width="100%" />
                                    </div>
                                </Slider>
                            </div>
                        </div>

                        <div className={cx('sum', 'col-5')}>
                            <div className={cx('prd-dir')}>
                                <Link to="/">home </Link>
                                &gt;
                                <Link to="/products"> shop </Link>
                                &gt;
                                <Link to="/products/bath-and-body"> bath & body </Link>
                                &gt;
                                <span className={cx('checked')}> blueberry gel cleanser</span>
                            </div>

                            <div className={cx('prd-star')}>
                                <div className={cx('star-rating')}>
                                    <FontAwesomeIcon className={cx('icon', { checked: true })} icon={faStar} />
                                    <FontAwesomeIcon className={cx('icon', { checked: true })} icon={faStar} />
                                    <FontAwesomeIcon className={cx('icon', { checked: true })} icon={faStar} />
                                    <FontAwesomeIcon className={cx('icon')} icon={faStar} />
                                    <FontAwesomeIcon className={cx('icon')} icon={faStar} />
                                </div>

                                <a href="#review" className={cx('review-count')}>
                                    (1 customer review)
                                </a>
                            </div>

                            <h1 className={cx('prd-name')}>blueberry gel cleanser</h1>
                            <div className={cx('prd-price')}>
                                {/* <div className={cx('range')}>$35.00 – $40.00</div> */}
                                <del className={cx('cost')}>$350</del>
                                <span className={cx('saleoff')}>$299</span>
                                <span className={cx('sale-label')}>-22%</span>
                            </div>

                            <div className={cx('prd-desc')}>
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor
                                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                                    pariatur.
                                </p>
                            </div>

                            <div className={cx('countdown-sale')}>
                                <h2 className={cx('title')}>
                                    <FontAwesomeIcon icon={faClock} />
                                    <span>Hurry up ! Deal ends in:</span>
                                </h2>
                                <div className={cx('clock')}></div>
                            </div>

                            <div className={cx('variations')}>
                                <div className={cx('quantity')}>
                                    <button className={cx('plus')}>
                                        <FontAwesomeIcon icon={faPlus} />
                                    </button>
                                    <input
                                        inputMode="numeric"
                                        type="number"
                                        min={1}
                                        value={1}
                                        autoComplete="off"
                                        max={20}
                                        name="quantity"
                                    />
                                    <button className={cx('minus')}>
                                        <FontAwesomeIcon icon={faMinus} />
                                    </button>
                                </div>

                                <button className={cx('add-to-cart', { 'hover-default': true })}>add to cart</button>
                            </div>

                            <div className={cx('add-wishlist')}>
                                <span className={cx('heart')}>
                                    <FontAwesomeIcon icon={faHeart} />
                                </span>
                                <span className={cx('label')}>Add to Wishlist</span>
                            </div>

                            <div className={cx('prd-meta')}>
                                <span className={cx('sku-wrapper', { 'meta-item': true })}>
                                    SKU: <span className={cx('sku')}>D2300-3-2-3</span>
                                </span>

                                <span className={cx('posted-in', { 'meta-item': true })}>
                                    Categories:
                                    <Link
                                        to="https://wpbingosite.com/wordpress/cerla/product-category/bath-body/"
                                        rel="tag"
                                        cursorshover="true"
                                    >
                                        Bath & Body
                                    </Link>
                                    ,
                                    <Link
                                        to="https://wpbingosite.com/wordpress/cerla/product-category/hair/"
                                        rel="tag"
                                        cursorshover="true"
                                    >
                                        Hair
                                    </Link>
                                    ,
                                    <Link
                                        to="https://wpbingosite.com/wordpress/cerla/product-category/lips/"
                                        rel="tag"
                                        cursorshover="true"
                                    >
                                        Lips
                                    </Link>
                                    ,
                                    <Link
                                        to="https://wpbingosite.com/wordpress/cerla/product-category/makeup/"
                                        rel="tag"
                                        cursorshover="true"
                                    >
                                        Makeup
                                    </Link>
                                </span>
                                <span className={cx('tagged-as', { 'meta-item': true })}>
                                    Tags:
                                    <Link
                                        to="https://wpbingosite.com/wordpress/cerla/product-tag/hot/"
                                        rel="tag"
                                        cursorshover="true"
                                    >
                                        Hot
                                    </Link>
                                    ,
                                    <Link
                                        to="https://wpbingosite.com/wordpress/cerla/product-tag/trend/"
                                        rel="tag"
                                        cursorshover="true"
                                    >
                                        Trend
                                    </Link>
                                </span>
                            </div>

                            <div className={cx('social-share')}>
                                <label className={cx('title')}>share: </label>
                                <div className={cx('social-icon')}>
                                    <Link>
                                        <FontAwesomeIcon className={cx('icon')} icon={faFacebook} />
                                    </Link>
                                    <Link>
                                        <FontAwesomeIcon className={cx('icon')} icon={faTwitter} />
                                    </Link>
                                    <Link>
                                        <FontAwesomeIcon className={cx('icon')} icon={faLinkedin} />
                                    </Link>
                                    <Link>
                                        <FontAwesomeIcon className={cx('icon')} icon={faInstagram} />
                                    </Link>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div className={cx('desc')}></div>
                </div>

                <div className={cx('prd-tab')}>
                    <div className={cx('tab-desc', 'container')}>
                        <h2 className={cx('title')}>description</h2>

                        <div className={cx('desc-content')}>
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                                incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                                exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure
                                dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
                                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt
                                mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit
                                voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo
                                inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim
                                ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur
                                magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui
                                dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam
                                eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.
                            </p>
                        </div>
                    </div>

                    <ReviewProduct />
                </div>

                <TrendingProduct titleComponent="related products" />
            </div>
        </div>
    );
}

export default ProductInfo;

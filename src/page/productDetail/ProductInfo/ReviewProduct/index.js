import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faStar } from '@fortawesome/free-solid-svg-icons';
import { PencilSquare } from 'react-bootstrap-icons';
import { ReviewProductCssModule } from '../../../../CssModule';

const cx = ReviewProductCssModule();

function ReviewProduct() {
    return (
        <div className={cx('wrapper')}>
            <div className={cx('content', 'container')}>
                <h2 className={cx('tab-title')}>reviews(1)</h2>
                <div className={cx('tab-review')}>
                    <div className={cx('comments')}>
                        <h2 className={cx('cmt-title')}>
                            1 review for <span className={cx('prd-name')}>blueberry gel cleanser</span>
                        </h2>
                        <ol className={cx('cmt-content')}>
                            <li>
                                <div className={cx('item')}>
                                    <div className={cx('item-user')}>
                                        <img src="https://secure.gravatar.com/avatar/53444f91e698c0c7caa2dbc3bdbf93fc?s=60&d=mm&r=g" />
                                        <div className={cx('star-rating')}>
                                            <FontAwesomeIcon className={cx('icon', { checked: true })} icon={faStar} />
                                            <FontAwesomeIcon className={cx('icon', { checked: true })} icon={faStar} />
                                            <FontAwesomeIcon className={cx('icon', { checked: true })} icon={faStar} />
                                            <FontAwesomeIcon className={cx('icon')} icon={faStar} />
                                            <FontAwesomeIcon className={cx('icon')} icon={faStar} />
                                        </div>
                                        <div className={cx('meta')}>
                                            <strong className={cx('review-author')}>huynh duc</strong>
                                            <time className={cx('published-date')}>January 11, 2021</time>
                                        </div>
                                    </div>

                                    <div className={cx('item-desc')}>
                                        <p>
                                            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod
                                            tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
                                            quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
                                        </p>
                                    </div>
                                </div>
                            </li>
                        </ol>
                    </div>

                    <div className={cx('review-form')}>
                        <div className={cx('cmt-respond')}>
                            <span className={cx('reply-title')}>
                                <PencilSquare className={cx('icon')} />
                                add a review
                            </span>
                            <form className={cx('reply-form')}>
                                <p className={cx('cmt-notes')}>
                                    Your email address will not be published. Required fields are marked{' '}
                                    <span className={cx('required')}>*</span>
                                </p>
                                <div className={cx('cmt-rating')}>
                                    <label>Your rating</label>
                                    <div className={cx('star-rating')}>
                                        <FontAwesomeIcon className={cx('icon', { checked: true })} icon={faStar} />
                                        <FontAwesomeIcon className={cx('icon', { checked: true })} icon={faStar} />
                                        <FontAwesomeIcon className={cx('icon', { checked: true })} icon={faStar} />
                                        <FontAwesomeIcon className={cx('icon')} icon={faStar} />
                                        <FontAwesomeIcon className={cx('icon')} icon={faStar} />
                                    </div>
                                </div>
                                <div className={cx('cmt-form', 'row')}>
                                    <div className={cx('cmt-form-info', 'col')}>
                                        <input
                                            className={cx('item')}
                                            type="text"
                                            placeholder="Name*"
                                            name="author_name"
                                        />
                                        <input
                                            className={cx('item')}
                                            type="text"
                                            placeholder="Email*"
                                            name="author_mail"
                                        />
                                        <button
                                            className={cx('item', {
                                                'hover-background-text': true,
                                                'item-submit': true,
                                            })}
                                            type="submit"
                                        >
                                            submit
                                        </button>
                                    </div>

                                    <div className={cx('cmt-form-text', 'col')}>
                                        <textarea placeholder="Youre Reviews*" name="respone" />
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default ReviewProduct;

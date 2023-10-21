import { RevenueCssModule } from "../../../CssModule";
import PostItem from "../../../components/PostItem";

const cx = RevenueCssModule()

function Revenue() {
    return ( 
        <div className={cx('wrapper', 'container-fluid')}>
            <div className={cx('main')}>
                <div className={cx('revenue-heading')}>
                    <h2 className={cx('revenue-heading-title')}>Real-life results and revenue</h2>
                    <p className={cx('revenue-heading-content')}>See how companies like yours have smashed their sales success goals</p>
                </div>

                <div className={cx('revenue-list')}>
                    <PostItem />
                    <PostItem />
                </div>
            </div>
        </div>
    );
}

export default Revenue;
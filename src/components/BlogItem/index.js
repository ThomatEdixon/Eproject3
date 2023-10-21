import { BlogItemCssModule } from "../../CssModule";

const cx = BlogItemCssModule();

function BlogItem() {
  return (
    <div className={cx("wrapper")}>
      <div className={cx("main")}>
        <h3 className={cx("news-heading")}>service</h3>

        <div className={cx("news-content")}>
          <img className={cx('news-img')} width="100%" height="100%" src="https://html-css-big-practice.vercel.app/article-1.8c7f4a97.webp" alt=""/>
          <h2 className={cx('news-title')}>How To Deliver a Successful Product Launch</h2>
          <p className={cx('news-date')}>
            05 Sep 2022, <span className={cx('news-author')}> by Joshua Nash</span>
          </p>
        </div>
      </div>
    </div>
  );
}

export default BlogItem;

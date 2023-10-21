import { BlogCssModule } from "../../../CssModule";
import BlogItem from "../../../components/BlogItem";

const cx = BlogCssModule();

function Blogs() {
  return (
    <div className={cx("wrapper", "container-fluid")}>
      <div className={cx("main")}>
        <div className={cx("news-heading")}>
          <h1 className={cx("news-heading-title")}>What's new at Yoora?</h1>
          <span className={cx("news-heading-link")}>
            <a href="#">See all</a>
            &gt;
          </span>
        </div>

        <div className={cx("news-list", "row")}>
          <div className="col-6">
            <BlogItem />
          </div>
          <div className="col-6">
            <BlogItem />
          </div>
        </div>
      </div>
    </div>
  );
}

export default Blogs;

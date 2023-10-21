import { FeedbackCssModule } from "../../../CssModule";
import PostItem from "../../../components/PostItem";

const cx = FeedbackCssModule();

function Feedback() {
  return (
    <div className={cx("wrapper", "container-fluid")}>
      <div className={cx("main")}>
        <div className={cx("feedback-heading")}>
          <h1 className={cx("feedback-heading-title")}>
            We love our Customers and They love us too
          </h1>
          <span className={cx("feedback-heading-link")}>
            <a href="#">See all</a>
            &gt;
          </span>
        </div>

        <div className={cx("feedback-list", "row")}>
          <div className="col-4">
            <PostItem feedback />
          </div>
          <div className="col-4">
            <PostItem feedback />
          </div>
          <div className="col-4">
            <PostItem feedback />
          </div>
        </div>
      </div>
    </div>
  );
}

export default Feedback;

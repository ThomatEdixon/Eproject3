import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { PostItemCssModule } from "../../CssModule";
import { faQuoteLeft } from "@fortawesome/free-solid-svg-icons";

const cx = PostItemCssModule()

function PostItem({feedback}) {
  return (
    <div className={cx("wrapper")}>
      {feedback && <FontAwesomeIcon className={cx('feedback-icon')} icon={faQuoteLeft} />}

      <div className={cx("main", {'d-block' : feedback})}>
        <div className={cx("postItem-heading")}>
          {
            !feedback && <><h2>$2.5 M</h2><h3>Generate sales</h3></>
          }
        </div>

        <div className={cx("postItem-content")}>
          <p className={cx("postItem-content-parag")}>
            Using Yoora CRM is one of the best decisions we've ever made. We've
            seen our annual revenue explode, and the outlook just keeps getting
            sunnier.
          </p>
          <div className={cx("postItem-content-author")}>
            <img
              className={cx("author-avt")}
              width={40}
              height={40}
              src="https://html-css-big-practice.vercel.app/nellie-foster.c421feb1.jpg"
              alt=""
            />
            <div className={cx("author-info")}>
              <h3>Nellie Foster</h3>
              <p>Founder & CEO, Foster Business Strategies</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default PostItem;

import { IntroductCssModule } from "../../../CssModule";

const cx = IntroductCssModule();

function Introduce() {
  return (
    <div className={cx("wrapper", "container-fluid")}>
      <div className={cx("main")}>
        <div className={cx('introduce-wrapper', 'row')}>
          <div className={cx("introduce-desc", 'col-7')}>
            <div className={cx("desc-content")}>
              <h2>Bringing companies and customers together, anywhere</h2>
              <p>
                An awesome & powerful tools for your business, increase business
                revenue with enterprise-grade links built to acquire and engage
                customers.
              </p>
            </div>

            <div className={cx("desc-try")}>
              <form className={cx("try-form")}>
                <input name="required_email" placeholder="Enter your email" />
                <button type="submit">Try for Free</button>
              </form>

              <p className={cx("try-message")}>
                Full access. No credit card required.
              </p>
            </div>
          </div>

          <div className={cx("introduce-image", 'col-5')}>
            <img src="https://html-css-big-practice.vercel.app/tool.645be2ca.svg" />
          </div>
        </div>

        <div className={cx("customer-wrapper", 'row')}>
          <div className={cx("customer-title", 'col-3')}>
            <h5>Trusted by 1,000+ customers</h5>
          </div>

          <div className={cx("customer-logo", 'col-9')}>
            <div className={cx("logo-item")}>
              <img width={120} height={40} src="https://html-css-big-practice.vercel.app/google.6f435d3b.svg" />
            </div>
            <div className={cx("logo-item")}>
              <img width={120} height={40} src="https://html-css-big-practice.vercel.app/atlassian-vector-logo.815a5e02.svg" />
            </div>
            <div className={cx("logo-item")}>
              <img width={120} height={40} src="https://html-css-big-practice.vercel.app/canon-wordmark-1.1de176b2.svg" />
            </div>
            <div className={cx("logo-item")}>
              <img width={120} height={40} src="https://html-css-big-practice.vercel.app/walmart-seeklogo.com.fa7d00ec.svg" />
            </div>
            <div className={cx("logo-item")}>
              <img width={120} height={40} src="https://html-css-big-practice.vercel.app/amazon-seeklogo.com.6e9c6d7a.svg" />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Introduce;

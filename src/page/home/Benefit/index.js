import { BenefitCssModule } from "../../../CssModule";

const cx = BenefitCssModule();

function Benefit() {
  return (
    <div className={cx("wrapper", "container-fluid")}>
      <div className={cx("main")}>
        <div className={cx("benefit-heading", "row")}>
          <h2 className={cx("title", "col-6")}>
            Here's how Yoora can benefit your business
          </h2>

          <p className={cx("content", "col-6")}>
            Build more meaningful and lasting relationships — better understand
            their needs, identify new opportunities to help, address any
            problems faster.
          </p>
        </div>

        <div className={cx("benefit-cards", "row")}>
          <div className={cx("card-item", "col-4")}>
            <div>
              <img src="https://html-css-big-practice.vercel.app/card-icon-1.4411539c.svg" />
              <div className={cx("card-item-content")}>
                <h4>Lead customers to happiness</h4>
                <p>
                  Yoora Support helps you provide personalized support when and
                  where customers need it, so customers stay happy.
                </p>
              </div>
            </div>
          </div>

          <div className={cx("card-item", "col-4")}>
            <div>
              <img src="https://html-css-big-practice.vercel.app/card-icon-2.76b1e5ab.svg" />
              <div className={cx("card-item-content")}>
                <h4>Support your support</h4>
                <p>
                  Productive agents are happy agents. Give them all the support
                  tools and information they need to best serve your customers.
                </p>
              </div>
            </div>
          </div>

          <div className={cx("card-item", "col-4")}>
            <div>
              <img src="https://html-css-big-practice.vercel.app/card-icon-3.a33683ef.svg" />
              <div className={cx("card-item-content")}>
                <h4>Grow without growing pains</h4>
                <p>
                  Our software is powerful enough to handle the most complex
                  business, yet flexible enough to scale with you as you grow.
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Benefit;

import { Link } from "react-router-dom";
import { SuperChargeCssModule } from "../../CssModule";

const cx = SuperChargeCssModule()

function SuperCharge() {
  return (
    <div className={cx("wrapper", 'container-fluid')}>
      <div className={cx("main", 'row')}>
        <div className={cx("supercharge-content", 'col-9')}>
          <h2>Ready to supercharge your business?</h2>

          <p>
            Ask about Yoora products, pricing, implementation, or anything else.
            Our highly trained reps are standing by, ready to help.
          </p>
        </div>

        <div className={cx("supercharge-navigate", 'col-3')}>
          <button><Link>Try for Free</Link> &gt;</button>
          <p>Full access. No credit card required.</p>
        </div>
      </div>
    </div>
  );
}

export default SuperCharge;

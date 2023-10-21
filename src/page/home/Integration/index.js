import { IntergrationCssModule, IntroductCssModule } from "../../../CssModule";

const cx = IntergrationCssModule()

function Integration() {
  return (
    <div className={cx("wrapper")}>
      <div className={cx("main")}>
        <div className={cx("inte-heading")}>
          <h3>Over 300+ integrations</h3>
          <p>
            Expand the capabilities of Yoora with hundreds of apps and
            integrations
          </p>
        </div>

        <div className={cx("inte-logos")}>
          <div className={cx('inte-logo-item')}>
            <img src="https://html-css-big-practice.vercel.app/zapier.7407e28c.png" />
          </div>
          <div className={cx('inte-logo-item', {"large":true})}>
            <img src="https://html-css-big-practice.vercel.app/hubspot.6485f325.png" />
          </div>
          <div className={cx('inte-logo-item', {"large":true})}>
            <img src="https://html-css-big-practice.vercel.app/zoom.7148d673.png" />
          </div>
          <div className={cx('inte-logo-item')}>
            <img src="https://html-css-big-practice.vercel.app/google-meet.6a066a98.png" />
          </div>
          <div className={cx('inte-logo-item', {"large":true})}>
            <img src="https://html-css-big-practice.vercel.app/zendesk.1ca94b9f.png" />
          </div>
          <div className={cx('inte-logo-item', {"large":true})}>
            <img src="https://html-css-big-practice.vercel.app/intercom.7b95b82a.png" />
          </div>
          <div className={cx('inte-logo-item')}>
            <img src="https://html-css-big-practice.vercel.app/trello.d80bb0a4.png" />
          </div>
          <div className={cx('inte-logo-item')}>
            <img src="https://html-css-big-practice.vercel.app/slack.4c0814cf.png" />
          </div>
          <div className={cx('inte-logo-item', {"large":true})}>
            <img src="https://html-css-big-practice.vercel.app/asana.0da131a2.png" />
          </div>
          <div className={cx('inte-logo-item')}>
            <img src="https://html-css-big-practice.vercel.app/microsoft-team.b0b99764.png" />
          </div>
        </div>
      </div>
    </div>
  );
}

export default Integration;

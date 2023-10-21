import { StatisticCardCssModule } from "../../../../CssModule";

const cx = StatisticCardCssModule();

function StatisticCard({order}) {
  return (
    <div className={cx("wrapper", "container-fluid")}>
      <div className={cx("main", "row")}>
        <div style={{order: order}} className={cx("stat-content", "col-6 p-0")}>
          <div className={cx("stat-content-tag")}>
            <span>sales</span>
          </div>

          <div className={cx("stat-content-subscript")}>
            <h3>Increase company revenue up to 65%</h3>
            <p>
              Automate your sales, marketing, and service in one platform. Avoid
              data leaks and enable consistent messaging.
            </p>
            <ul className="list-group">
              <li className='list-group-item border-0 ps-0 pe-0'>
                <img width={24} height={24} src="https://html-css-big-practice.vercel.app/done-mark.0966920e.svg" />
                <span>
                  Close more deals with single-page contact management
                </span>
              </li>
              <li className='list-group-item border-0 ps-0 pe-0'>
                <img width={24} height={24} src="https://html-css-big-practice.vercel.app/done-mark.0966920e.svg" />
                <span>
                  Enjoy one-click calling, call scripts and voicemail automation
                </span>
              </li>
              <li className='list-group-item border-0 ps-0 pe-0'>
                <img width={24} height={24} src="https://html-css-big-practice.vercel.app/done-mark.0966920e.svg" />
                <span>
                  Track stages and milestones of your deals to keep the sales
                  process on track
                </span>
              </li>
            </ul>
          </div>
        </div>

        <div className={cx("stat-image", "col-6 p-0")}>
          <img src="https://html-css-big-practice.vercel.app/sale.8b65a6d7.svg" />
        </div>
      </div>
    </div>
  );
}

export default StatisticCard;

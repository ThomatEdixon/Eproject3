import { StatisticCssModule } from "../../../CssModule";
import StatisticCard from "./StatisticCard";

const cx = StatisticCssModule()

function Statistic() {
    return ( 
        <div className={cx('wrapper')}>
            <div className={cx('main')}>
                <div className={cx('statistic-cards')}>
                    <StatisticCard />
                    <StatisticCard order={2} />
                    <StatisticCard />
                </div>
            </div>
        </div>
     );
}

export default Statistic;
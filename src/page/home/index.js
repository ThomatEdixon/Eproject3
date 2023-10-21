import SuperCharge from "../../components/SuperCharge";
import Benefit from "./Benefit";
import Blogs from "./Blogs";
import Feedback from "./Feedback";
import Integration from "./Integration";
import Introduce from "./Introduce";
import Revenue from "./Revenue";
import Statistic from "./Statistic";

function Home() {
    return ( 
        <div >
            <Introduce/>
            <Benefit />
            <Statistic />
            <Integration />
            <Blogs />
            <Revenue />
            <Feedback />
            <SuperCharge />
        </div>
     );
}

export default Home;
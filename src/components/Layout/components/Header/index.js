import { Link } from "react-router-dom";
import { HeaderCssModule } from "../../../../CssModule";

const cx = HeaderCssModule();

function Header() {
  return (
    <header className={cx("wrapper", "container-fluid")}>
      <div className={cx("content")}>
        <div className={cx("menu")}>
          <div className={cx("logo")}>
            <Link to="/">
              <img
                width="106"
                height="22"
                src="https://html-css-big-practice.vercel.app/logo.162faf9f.svg"
              />
            </Link>
          </div>

          <nav className={cx("navigator")}>
            <ul className="list-group list-group-horizontal">
              <li className="list-group-item border-0">
                <Link to="/product">Product</Link>
              </li>
              <li className="list-group-item border-0">
                <Link>Pricing</Link>
              </li>
              <li className="list-group-item border-0">
                <Link>Company</Link>
              </li>
              <li className="list-group-item border-0">
                <Link>Resource</Link>
              </li>
              <li className="list-group-item border-0">
                <Link>Contact</Link>
              </li>
            </ul>
          </nav>
        </div>

        <div className={cx("actions")}>
          <button className={cx("btn-login")}>
            <Link to="/register">Log In</Link>
          </button>
          <button className={cx("btn-try")}>Try for Free</button>
        </div>
      </div>
    </header>
  );
}

export default Header;

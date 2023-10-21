import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { FooterCssModule } from "../../../../CssModule";
import { Link } from "react-router-dom";
import { faGlobe } from "@fortawesome/free-solid-svg-icons";

const cx = FooterCssModule();

function Footer() {
  return (
    <footer className={cx("wrapper", "container-fluid")}>
      <div className={cx("main")}>
        <div className={cx("footer-content", "row")}>
          <div className={cx("summary", "col-4")}>
            <img
              width="106"
              height="22"
              className={cx("sum-logo")}
              src="https://html-css-big-practice.vercel.app/logo.162faf9f.svg"
            />
            <p className={cx("sum-content")}>
              We built an elegant solution. Our team created a fully integrated
              sales and marketing solution for SMBs
            </p>
            <div className={cx("sum-social")}>
              <a href="#" className={cx("twitter")}></a>
              <a href="#" className={cx("facebook")}></a>
              <a href="#" className={cx("linkedin")}></a>
            </div>
          </div>
          <div className={cx("list-menu", "col-8")}>
            <div className="d-flex justify-content-between">
              <div className={cx("footer-menu")}>
                <h3 className={cx("menu-title")}>company</h3>

                <ul className={cx("menu-wrapper", "list-group")}>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>About</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Product</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Pricing</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Contact</Link>
                  </li>
                </ul>
              </div>
              <div className={cx("footer-menu")}>
                <h3 className={cx("menu-title")}>company</h3>

                <ul className={cx("menu-wrapper", "list-group")}>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>About</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Product</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Pricing</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Contact</Link>
                  </li>
                </ul>
              </div>
              <div className={cx("footer-menu")}>
                <h3 className={cx("menu-title")}>company</h3>

                <ul className={cx("menu-wrapper", "list-group")}>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>About</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Product</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Pricing</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Contact</Link>
                  </li>
                </ul>
              </div>
              <div className={cx("footer-menu")}>
                <h3 className={cx("menu-title")}>company</h3>

                <ul className={cx("menu-wrapper", "list-group")}>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>About</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Product</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Pricing</Link>
                  </li>
                  <li className="list-group-item p-3 ps-0 border-0">
                    <Link>Contact</Link>
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </div>

        <div className={cx("footer-wrapper")}>
          <div className={cx("footer-copyright")}>
            <p className={cx("title")}>© Copyright 2022 Yoora, Inc.</p>
            <ul
              className={cx("legal-list", "list-group list-group-horizontal")}
            >
              <li className={cx("list-group-item border-0")}>
                <Link>Terms of Service</Link>
              </li>
              <li className={cx("list-group-item border-0")}>
                <Link>Privacy Policy</Link>
              </li>
              <li className={cx("list-group-item border-0")}>
                <Link>Cookies</Link>
              </li>
            </ul>
            <div className={cx("language-switcher")}>
              <FontAwesomeIcon className={cx('icon')} icon={faGlobe} />
              <select className={cx('list')}>
                <option>English</option>
                <option>Vietnamese</option>
                <option>Thailand</option>
              </select>
            </div>
          </div>
        </div>
      </div>
    </footer>
  );
}

export default Footer;

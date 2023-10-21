import Slider from "react-slick";
import Modals from "../Modals";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faAngleLeft,
  faAngleRight,
  faMinus,
  faPlus,
} from "@fortawesome/free-solid-svg-icons";
import { useRef } from "react";
import { ProductPreviewCssModule } from "../../CssModule";

const cx = ProductPreviewCssModule();

function ProductPreview({ handleVisible, visible }) {
  const sliderRef = useRef();

  const settings = {
    dots: true,
    infinite: true,
    slidesToShow: 1,
    slidesToScroll: 1,
    swipeToSlide: true,
    arrows: false,
  };

  return (
    <Modals
      mw="1070px"
      size="xl"
      animation="fade"
      handleVisible={handleVisible}
      visible={visible}
    >
      <div className={cx("wrapper")}>
        <div className="container p-0" style={{ maxHeight: "inherit" }}>
          <div className="row g-0" style={{ maxHeight: "inherit" }}>
            <div
              className={cx("item", { "prd-thumb": true }, "col-6")}
              style={{ maxHeight: "inherit" }}
            >
              <Slider ref={sliderRef} {...settings}>
                <div>
                  <img src="https://wpbingosite.com/wordpress/cerla/wp-content/webp-express/webp-images/uploads/2018/05/BLUEBERRY-LUDICROUS-LIP-1020x1020.jpg.webp"></img>
                </div>
                <div>
                  <img src="https://wpbingosite.com/wordpress/cerla/wp-content/webp-express/webp-images/uploads/2018/05/BLUEBERRY-LUDICROUS-LIP-1020x1020.jpg.webp"></img>
                </div>
              </Slider>
              <div className={cx("slider-arrows")}>
                <button
                  onClick={() => sliderRef.current.slickPrev()}
                  className={cx("btn-prev")}
                >
                  <FontAwesomeIcon className={cx("icon")} icon={faAngleLeft} />
                </button>
                <button
                  onClick={() => sliderRef.current.slickNext()}
                  className={cx("btn-next")}
                >
                  <FontAwesomeIcon className={cx("icon")} icon={faAngleRight} />
                </button>
              </div>
            </div>
            <div
              className={cx("item", { "prd-info": true }, "col-6")}
              style={{ maxHeight: "inherit" }}
            >
              <div className={cx("content")}>
                <h2 className={cx("prd-title")}>avovado makeup melter</h2>
                <div className={cx("prd-price")}>
                  <div className={cx("range")}>$35.00 – $40.00</div>
                  {/* <del className={cx('cost')}>$350</del>
                                    <span className={cx('saleoff')}>$299</span> */}
                  <span className={cx("sale-label")}>-22%</span>
                </div>
                <p className={cx("prd-desc")}>
                  The EcoSmart Fleece Hoodie full-zip hooded jacket provides
                  medium weight fleece comfort all year around.…
                </p>
                <select className={cx("prd-option")}>
                  <option>Choose an option</option>
                  <option>green</option>
                  <option>red</option>
                </select>
                <div className={cx("prd-total")}>
                  <div className={cx("price")}>
                    <del className={cx("cost")}>$350</del>
                    <span className={cx("saleoff")}>$299</span>
                  </div>
                  <div className={cx("prd-inStock")}>43 in stock</div>
                </div>
                <div className={cx("variations")}>
                  <div className={cx("quantity")}>
                    <button className={cx("plus")}>
                      <FontAwesomeIcon icon={faPlus} />
                    </button>
                    <input
                      inputMode="numeric"
                      type="number"
                      min={1}
                      value={1}
                      autoComplete="off"
                      max={20}
                      name="quantity"
                    />
                    <button className={cx("minus")}>
                      <FontAwesomeIcon icon={faMinus} />
                    </button>
                  </div>

                  <button className={cx("add-to-cart")}>add to cart</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </Modals>
  );
}

export default ProductPreview;

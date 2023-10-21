import classNames from "classnames/bind";
import HeaderStyles from "../components/Layout/components/Header/Header.module.scss";
import FooterStyles from "../components/Layout/components/Footer/Footer.module.scss";
import IntroduceStyles from "../page/home/Introduce/Introduce.module.scss";
import BenefitStyles from "../page/home/Benefit/Benefit.module.scss";
import StatisticStyles from "../page/home/Statistic/Statistic.module.scss";
import StatisticCardStyles from "../page/home/Statistic/StatisticCard/StatisticCard.module.scss";
import IntergrationStyles from "../page/home/Integration/Intergration.module.scss"
import BlogItemStyles from "../components/BlogItem/BlogItem.module.scss"
import BlogStyles from "../page/home/Blogs/Blogs.module.scss"
import PostItemStyles from "../components/PostItem/PostItem.module.scss";
import RevenueStyles from "../page/home/Revenue/Revenue.module.scss";
import FeedbackStyles from "../page/home/Feedback/Feedback.module.scss";
import SuperChargeStyles from "../components/SuperCharge/SuperCharge.module.scss";
import RegisterStyles from "../page/register/Register.module.scss";
import SidebarStyles from "../page/product/Sidebar/Sidebar.module.scss"
import ListProductStyles from "../page/product/ListProduct/ListProduct.module.scss"
import ModalsStyles from "../components/Modals/Modals.module.scss"
import ProductItemStyles from "../components/ProductItem/ProductItem.module.scss"
import ProductPreviewStyles from "../components/ProductPreview/ProductPreview.module.scss"
import ReviewProductStyles from "../page/productDetail/ProductInfo/ReviewProduct/ReviewProduct.module.scss"
import ProductInfoStyles from "../page/productDetail/ProductInfo/ProductInfo.module.scss"
import TredingProductStyles from "../components/TrendingProduct/TredingProduct.module.scss"

function HeaderCssModule() {
  const cx = classNames.bind(HeaderStyles);
  return cx;
}

function FooterCssModule() {
  const cx = classNames.bind(FooterStyles);
  return cx;
}

function IntroductCssModule() {
  const cx = classNames.bind(IntroduceStyles);
  return cx;
}

function BenefitCssModule() {
  const cx = classNames.bind(BenefitStyles);
  return cx;
}

function StatisticCardCssModule() {
  const cx = classNames.bind(StatisticCardStyles);
  return cx;
}

function StatisticCssModule() {
  const cx = classNames.bind(StatisticStyles);
  return cx;
}

function IntergrationCssModule() {
  const cx = classNames.bind(IntergrationStyles);
  return cx;
}

function BlogItemCssModule() {
  const cx = classNames.bind(BlogItemStyles);
  return cx;
}

function BlogCssModule() {
  const cx = classNames.bind(BlogStyles);
  return cx;
}

function PostItemCssModule() {
  const cx = classNames.bind(PostItemStyles);
  return cx;
}

function RevenueCssModule() {
  const cx = classNames.bind(RevenueStyles);
  return cx;
}

function FeedbackCssModule() {
  const cx = classNames.bind(FeedbackStyles);
  return cx;
}

function SuperChargeCssModule() {
  const cx = classNames.bind(SuperChargeStyles);
  return cx;
}

function RegisterCssModule() {
  const cx = classNames.bind(RegisterStyles);
  return cx;
}

function SidebarCssModule() {
  const cx = classNames.bind(SidebarStyles);
  return cx;
}

function ModalsCssModule() {
  const cx = classNames.bind(ModalsStyles);
  return cx;
}

function ProductItemCssModule() {
  const cx = classNames.bind(ProductItemStyles);
  return cx;
}

function ProductPreviewCssModule() {
  const cx = classNames.bind(ProductPreviewStyles);
  return cx;
}

function ListProductCssModule() {
  const cx = classNames.bind(ListProductStyles);
  return cx;
}

function ReviewProductCssModule() {
  const cx = classNames.bind(ReviewProductStyles);
  return cx;
}

function ProductInfoCssModule() {
  const cx = classNames.bind(ProductInfoStyles);
  return cx;
}

function TredingProductCssModule() {
  const cx = classNames.bind(TredingProductStyles);
  return cx;
}

export {
  HeaderCssModule,
  FooterCssModule,
  IntroductCssModule,
  BenefitCssModule,
  StatisticCardCssModule,
  StatisticCssModule,
  IntergrationCssModule,
  BlogItemCssModule,
  BlogCssModule,
  PostItemCssModule,
  RevenueCssModule,
  FeedbackCssModule,
  SuperChargeCssModule,
  RegisterCssModule,
  SidebarCssModule,
  ModalsCssModule,
  ProductItemCssModule,
  ProductPreviewCssModule,
  ListProductCssModule,
  ReviewProductCssModule,
  ProductInfoCssModule,
  TredingProductCssModule,
};

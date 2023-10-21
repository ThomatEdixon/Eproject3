import { Modal } from 'react-bootstrap';
import { ModalsCssModule } from '../../CssModule';

const cx = ModalsCssModule()

function Modals({ handleVisible, visible, children, animation, size}) {
    return (
        <Modal className="p-0" size={size} centered="true" animation={animation} show={visible}>
            <div className={cx('wrapper')}>
                {children}

                <div
                    onClick={() => {
                        handleVisible(false);
                    }}
                    className={cx('close')}
                >
                    <span>&#8212;</span>
                    <span>&#8212;</span>
                </div>
            </div>
        </Modal>
    );
}

export default Modals;

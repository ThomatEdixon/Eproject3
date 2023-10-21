import { Button, Form, Input, Select, Space } from "antd";
import { RegisterCssModule } from "../../CssModule";
import { useForm } from "antd/es/form/Form";
import { useEffect, useState } from "react";

const cx = RegisterCssModule();

const SubmitButton = ({ form }) => {
  const [submittable, setSubmittable] = useState(false);

  // Watch all values
  const values = Form.useWatch([], form);
  useEffect(() => {
    form
      .validateFields({
        validateOnly: true,
      })
      .then(
        () => {
          setSubmittable(true);
        },
        () => {
          setSubmittable(false);
        }
      );
  }, [values]);
  return (
    <Button type="primary" htmlType="submit" disabled={!submittable}>
      Submit
    </Button>
  );
};

function Register() {
  const [form] = useForm();

  return (
    <div className={cx("wrapper")}>
      <div className={cx("main")}>
        <Form
          className={cx("form-register", "container-fluid")}
          form={form}
          layout="vertical"
          style={{
            maxWidth: "600px",
          }}
          requiredMark="optional"
          autoComplete="off"
        >
          <Form.Item
            rules={[
              {
                required: true,
              },
            ]}
            label="Name"
            name="name"
            colon={true}
          >
            <Input placeholder="Input your name" />
          </Form.Item>
          <Form.Item
            rules={[
              {
                required: true,
              },
            ]}
            label="Phone"
            name="phone"
            colon={true}
          >
            <Input placeholder="Input your phone" />
          </Form.Item>
          <Form.Item
            rules={[
              {
                required: true,
              },
            ]}
            label="Address"
            name="address"
            colon={true}
          >
            <Input placeholder="Input your address" />
          </Form.Item>
          <Form.Item
            rules={[
              {
                required: true,
              },
            ]}
            label="Email"
            name="email"
            colon={true}
          >
            <Input placeholder="Input your phone" />
          </Form.Item>
          <Form.Item
            rules={[
              {
                required: true,
              },
            ]}
            label="Password"
            name="password"
            colon={true}
          >
            <Input placeholder="Input your phone" />
          </Form.Item>
          <Form.Item
            rules={[
              {
                required: true,
              },
              ({ getFieldValue }) => ({
                validator(_, value) {
                  if (!value || getFieldValue('password') === value) {
                    return Promise.resolve();
                  }
                  return Promise.reject(new Error('The new password that you entered do not match!'));
                },
              }),
            ]}
            label="Confirm Password"
            name="confirm_password"
            dependencies={['password']}
            colon={true}
          >
            <Input placeholder="Input your phone" />
          </Form.Item>
          <Form.Item>
            <Space>
              <SubmitButton form={form} />
              <Button htmlType="reset">Reset</Button>
            </Space>
          </Form.Item>
        </Form>
      </div>
    </div>
  );
}

export default Register;

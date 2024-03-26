import UseLogin from "../../shared/components/apiService/AuthService";
import LoginFormElement from "../../shared/consts/models/formElements/LoginElement";
import "./Auth.scss";

const Auth = () => {
  const { mutateAsync } = UseLogin();
  const handleSubmit = (event: React.FormEvent<LoginFormElement>) => {
    event.preventDefault();
  };

  return (
    <div className="login-form">
      <form onSubmit={handleSubmit}>
        <h2>Osu Map Finder</h2>
        <p className="mb-5">Some desc</p>
        <div className="mb-3">
          <input
            className="input-form"
            type="text"
            name="username"
            placeholder="Username"
          />
        </div>
        <div className="mb-3">
          <input
            className="input-form"
            type="password"
            name="password"
            placeholder="Password"
          />
        </div>
        <div className="check-form mb-4">
          <input
            type="checkbox"
            className="form-check-input mt-0 checkbox"
            value=""
            id="checkbox-input"
          />
          <label htmlFor="checkbox-input" className="ms-2">
            Check me out
          </label>
        </div>
        <button className="button" type="submit">
          Submit
        </button>
      </form>
    </div>
  );
};

export default Auth;

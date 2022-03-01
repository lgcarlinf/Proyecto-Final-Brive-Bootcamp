import styled from "styled-components";

export const StyledLogin = styled.div`
  width: 100%;
  background-color: #fff;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  padding: 40px;
  .header {
    text-align: left;

    p {
      font-size: 0.9rem;
      color: #6f6f6f;
    }

    span {
      display: block;
      border-bottom: 2px solid #2e55fa;
      width: 20px;
    }
    .logo {
      width: 180px;
    }
  }

  form {
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;

    .input-user,
    .input-pass {
      display: block;
      height: 30px;
      width: 100%;
      margin: 10px 0;
      padding: 10px;
      border: none;
      box-shadow: 0 0 10px 0 rgb(0 24 128 / 10%);
    }

    .input-user:focus,
    .input-pass:focus {
      outline: none;
    }
  }

  .login {
    width: 100%;
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin: 20px;

    .input-submit {
      background-color: #2e55fa;
      color: #fff;
      padding: 15px;
      border-radius: 3px;
      border: none;
      font-size: 1rem;
      font-weight: bold;
      cursor: pointer;
    }

    label {
      color: #2e55fa;
      font-size: 1.1rem;
    }
  }

  .container-create {
    width: 100%;
    margin: 0 auto;
    margin-top: 40px;

    a {
      text-decoration: none;
      width: 100%;
      background-color: #2e55fa;
      color: #fff;
      border: none;
      padding: 15px;
      border-radius: 3px;
      font-size: 1.1rem;
      font-weight: bold;
      cursor: pointer;
    }
  }

  @media screen and (min-width: 768px) {
    width: 35vw;
    form {
      width: 100%;
    }
  }
`;

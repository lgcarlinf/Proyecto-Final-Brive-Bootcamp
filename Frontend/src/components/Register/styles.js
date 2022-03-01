import styled from "styled-components";

export const StyledRegister = styled.div`
  width: 100%;
  background-color: #fff;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  padding: 40px;
  .header {
    text-align: left;
    .logo {
      width: 180px;
    }

    p {
      font-size: 0.9rem;
      color: #6f6f6f;
    }

    span {
      display: block;
      border-bottom: 2px solid #2e55fa;
      width: 20px;
    }
  }

  form {
    width: 100%;
    display: flex;
    flex-direction: column;

    input {
      width: 100%;
      display: block;
      height: 30px;
      margin: 10px 0;
      padding: 10px;
      border: none;
      box-shadow: 0 0 10px 0 rgb(0 24 128 / 10%);
    }

    input:focus {
      outline: none;
    }

    .terms {
      display: flex;
      align-items: center;
      justify-content: flex-start;
    }

    .checkbox {
      display: inline-block;
      width: 20px;
    }

    label {
      font-size: 0.9rem;
      display: inline-block;
      margin-left: 10px;
      color: #6f6f6f;

      span {
        color: #2e55fa;
      }
    }

    .container-buttons {
      display: flex;
      align-items: center;
      justify-content: space-between;

      a {
        text-decoration: none;
        width: 100px;
        background-color: transparent;
        border: 1px solid #6f6f6f;
        color: #6f6f6f;
        line-height: 35px;
        height: 40px;
        border-radius: 3px;
        font-weight: bold;
        cursor: pointer;
      }

      input {
        width: 120px;
        background-color: #2e55fa;
        color: #fff;
        border: none;
        border-radius: 3px;
        height: 40px;
        font-weight: bolder;
        font-size: 0.96rem;
        cursor: pointer;
      }
    }
  }

  @media screen and (min-width: 768px) {
    position: absolute;
    width: 35%;
    form {
      width: 100%;
    }
  }
`;

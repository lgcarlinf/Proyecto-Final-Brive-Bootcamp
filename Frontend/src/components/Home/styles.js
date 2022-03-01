import styled from "styled-components";
import imagen from "../../assets/home.jpg";

export const StyledHome = styled.div`
  .nav {
    display: flex;
    justify-content: space-between;
    align-items: center;
    height: 100px;
    border-bottom: 1px solid #e6e6e6;
    padding: 0 10px;

    img {
      display: block;
      height: 40%;
    }

    .acc-options {
      height: 100%;
      display: flex;
      flex-direction: column;
      justify-content: space-evenly;
      align-items: center;

      a {
        text-decoration: none;
      }

      button {
        border: none;
        background-color: #2e55fa;
        color: #fff;
        border-radius: 3px;
        font-size: 1rem;
        font-weight: bold;
        padding: 0.5rem 1rem;
        cursor: pointer;
      }
    }
  }
  .content {
    position: relative;
    background-image: url(${imagen});
    height: 500px;
    width: 100%;

    &::after {
      content: "";
      height: 100%;
      width: 100%;
      left: 0;
      top: 0;
      position: absolute;
      background: linear-gradient(
        to right,
        rgba(255, 255, 255, 0.9) 40%,
        rgba(125, 185, 232, 0) 100%
      );
      z-index: 1;
    }

    .text-content {
      display: flex;
      flex-direction: column;
      align-items: center;
      height: 500px;
      position: absolute;
      z-index: 9;
      top: 50%;
      left: 0;
      right: 0;
      bottom: 0;
      margin: auto;

      span.subtitle {
        display: block;
        background-color: #2e55fa;
        color: #fff;
        border-radius: 3px;
        padding: 0.2rem 0.5rem;
      }

      h1 {
        font-size: 3rem;

        span {
          color: #2e55fa;
        }
      }

      .content-searchbar {
        width: 80%;
        height: 100px;
        display: flex;
        flex-direction: column;
        justify-content: space-evenly;
        padding: 10px;
        background-color: #fff;
        border-radius: 3px;

        .input-text {
          border: none;
          border-bottom: 2px solid #2e55fa;

          &:focus {
            outline: none;
          }
        }

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
      }
    }
  }

  .result {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

    .description {
      display: flex;
      justify-content: center;
      align-items: center;
      font-weight: bolder;
      text-transform: uppercase;
    }

    .info {
      display: flex;
      justify-content: center;
      align-items: center;
      font-weight: bolder;
    }
    p {
      padding: 0 30px;
    }
  }
  @media screen and (min-width: 768px) {
    .nav {
      height: 80px;
      padding: 0 40px;

      img {
        height: 40%;
      }

      .acc-options {
        width: 250px;
        display: flex;
        flex-direction: row;
      }
    }

    .content .text-content .content-searchbar {
      width: 600px;
      display: flex;
      flex-direction: row;
      align-items: center;
      height: 80px;

      .input-text {
        width: 50%;
        font-size: 1.2rem;
      }

      .input-submit {
        height: 50px;
      }
    }
  }
`;

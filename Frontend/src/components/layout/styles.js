import styled from "styled-components";

export const StyledMain = styled.div`
  width: 100%;
  display: flex;
  justify-content: space-between;
  height: 100vh;

  .img-main {
    display: none;
  }

  @media screen and (min-width: 768px) {
    .img-main {
      object-fit: cover;
      z-index: -1;
      position: fixed;
      display: block;
      top: 0;
      right: 0;
      width: 65vw;
      height: 100vh;
    }
  }
`;

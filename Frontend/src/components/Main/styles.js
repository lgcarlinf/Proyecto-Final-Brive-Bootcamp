import styled from "styled-components";

export const StyledMain = styled.div`
  display: flex;
  height: 100vh;
  .img-main {
    width: 65%;
    height: 100vh;
    object-fit: cover;
  }

  @media (max-width: 768px) {
    .img-main {
      display: none;
    }
  }
`;

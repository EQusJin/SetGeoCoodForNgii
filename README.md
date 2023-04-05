# 국토지리정보원 정사영상 좌표입력 프로그램 only for 1:5000

국토지리정보원 통합플랫폼에서 정사영상을 다운받은 경우 좌표계가 존재 하지 않음

이 프로그램은 1:5000 인덱스를 기준으로 국토지리정보원에서 다운받은 정사영상에 

좌표를 적용시켜 GeoTiff로 변환시켜 줌

국토지리정보원에서 제공하는 1:5000 인덱스를 다운 받은 경우 

GDALTranslateOptions opts = new GDALTranslateOptions(new string[ {"-a_srs", "EPSG:5186",  
"-of", "GTiff",  
"-a_ullr", $"{ngii.LeftTop5k.X - 50}", $"{ngii.LeftTop5k.Y + 50}", $"{ngii.RightBottom5k.X + 50}", $"{ngii.RightBottom5k.Y - 50}" });
                                
위 소스로 수정 하여 버퍼 크기 적용 시켜야 함

## **국토지리정보원에서 다운받은 영상은 정확한 좌표부여가 불가능하니 참고용으로만 사용**

## **정확한 좌표가 필요하면 국토지리정보원에 GeoTiff나 tfw 파일 요청**

***2023 / 04 / 05***

* 문제점 1.  
  프로그램 실행 경로에 한글 폴더명이 있을 경우 "Failed to process SRS definition : EPSG:5186 오류 발생 
